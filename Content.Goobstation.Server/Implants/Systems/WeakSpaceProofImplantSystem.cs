// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-FileCopyrightText: 2025 Solstice <solsticeofthewinter@gmail.com>
// SPDX-FileCopyrightText: 2025 SolsticeOfTheWinter <solsticeofthewinter@gmail.com>
// SPDX-FileCopyrightText: 2025 cohanna <conornhanna@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Server.Implants.Components;
using Content.Goobstation.Shared.Temperature.Components;
using Content.Server.Atmos.Components;
using Content.Shared._Shitmed.Body.Components;
using Content.Shared.Implants;
using Content.Shared.Temperature.Components;
using Robust.Shared.Containers;

namespace Content.Goobstation.Server.Implants.Systems;

public sealed class WeakSpaceProofImplantSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<WeakSpaceProofImplantComponent, ImplantImplantedEvent>(OnImplant);
        SubscribeLocalEvent<WeakSpaceProofImplantComponent, EntGotRemovedFromContainerMessage>(OnUnimplanted);
    }

    private void OnImplant(Entity<WeakSpaceProofImplantComponent> ent, ref ImplantImplantedEvent args)
    {
        if (!args.Implanted.HasValue)
            return;

        var user = args.Implanted.Value;

        EnsureComp<PressureImmunityComponent>(user);
        EnsureComp<SpecialLowTempImmunityComponent>(user);
    }

    private void OnUnimplanted(Entity<WeakSpaceProofImplantComponent> ent, ref EntGotRemovedFromContainerMessage args)
    {
        var user = args.Container.Owner;

        if (!TerminatingOrDeleted(user))
            RemCompDeferred<PressureImmunityComponent>(user);
        if (!TerminatingOrDeleted(user))
            RemCompDeferred<SpecialLowTempImmunityComponent>(user);
    }
}
